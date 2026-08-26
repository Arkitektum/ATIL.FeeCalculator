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


resource appServicePlan 'Microsoft.Web/serverfarms@2024-11-01' existing = {
  name: aspName
  scope: resourceGroup(rgSharedResources)
}

resource AppServiceApp 'Microsoft.Web/sites@2024-11-01' = {
  name: appName
  location: location
  kind: 'app,linux'
  identity: {
    type: 'SystemAssigned'
  }
  
  properties: {
    serverFarmId: appServicePlan.id
    httpsOnly: true
    publicNetworkAccess: 'Disabled'
    clientAffinityEnabled: false
    virtualNetworkSubnetId: resourceId(rgSharedResources,'Microsoft.Network/virtualNetworks/subnets', vnetName, connectivitySubnet)
    siteConfig: {
      linuxFxVersion: stackVersion
      appCommandLine: startCommand
      healthCheckPath: '/health'
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

  // Azure maintains the A records for every FQDN this endpoint serves,
  // and keeps them in sync if the private IP ever changes.
  resource dnsZoneGroup 'privateDnsZoneGroups' = {
    name: 'default'
    properties: {
      privateDnsZoneConfigs: [
        {
          name: replace(privateDnsZoneName, '.', '-')
          properties: {
            privateDnsZoneId: resourceId(rgSharedResources, 'Microsoft.Network/privateDnsZones', privateDnsZoneName)
          }
        }
      ]
    }
  }
}

