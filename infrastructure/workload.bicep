param location string
param appName string
param rgSharedResources string
param aspName string
param privateDnsZoneName string
param vnetName string
param subnetName string
param connectivitySubnet string
param stackVersion string
param startCommand string


resource appServicePlan 'Microsoft.Web/serverfarms@2021-01-15' existing = {
  name: aspName
  scope: resourceGroup(rgSharedResources)
}

resource AppServiceApp 'Microsoft.Web/sites@2021-01-15' = {
  name: appName
  location: location
  identity: {
    type: 'SystemAssigned'
  }
  
  properties: {
    serverFarmId: appServicePlan.id
    httpsOnly: true
    clientAffinityEnabled: false
    virtualNetworkSubnetId: resourceId(rgSharedResources,'Microsoft.Network/virtualNetworks/subnets', vnetName, connectivitySubnet)
    siteConfig: {
      linuxFxVersion: stackVersion
      appCommandLine: startCommand
      appSettings: [
        {
          name: 'WEBSITE_WEBDEPLOY_USE_SCM'
          value: 'false'
        }
        {
          name: 'SCM_DO_BUILD_DURING_DEPLOYMENT'
          value: 'false'
        }
      ]
    }
  }
}

resource stagingSlot 'Microsoft.Web/sites/slots@2021-02-01' = {
  name: 'staging'
  parent: AppServiceApp
  location: location
  kind: 'app'
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    serverFarmId: appServicePlan.id
  }
}

var privateEndpointName = 'pe-${appName}'

resource privateEndpoint 'Microsoft.Network/privateEndpoints@2023-05-01' = {
  name: privateEndpointName
  location: location
  properties: {
    subnet: {
      id: resourceId(rgSharedResources,'Microsoft.Network/virtualNetworks/subnets', vnetName, subnetName)
    }
    privateLinkServiceConnections: [
      {
        name: privateEndpointName
        properties: {
          groupIds: ['sites']
          privateLinkServiceId: AppServiceApp.id
        }
      }
    ]
  }
}

module addToPrivateDns 'AddToPrivateDns.bicep' = {
  name: 'addToPrivateDns'
  params: {
    privateDnsZoneName: privateDnsZoneName
    privateEndpointName: privateEndpointName
    appResourceGroupName: resourceGroup().name
    appName: appName
  }
  dependsOn: [privateEndpoint]
  scope: resourceGroup(rgSharedResources)
}

