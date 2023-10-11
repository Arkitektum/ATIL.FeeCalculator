param privateEndpointName string
param appResourceGroupName string
param privateDnsZoneName string
param appName string


resource privateEndpoint 'Microsoft.Network/privateEndpoints@2023-05-01' existing = {
  name: privateEndpointName
  scope: resourceGroup(appResourceGroupName)
}
resource privateDNSZone 'Microsoft.Network/privateDnsZones@2020-06-01' existing = {
  name: privateDnsZoneName
}

resource privateDNSRecordSet 'Microsoft.Network/privateDnsZones/A@2020-06-01' = {
  name: appName
  parent: privateDNSZone
  properties: {
    ttl: 3600
    aRecords: [
      {
        ipv4Address: privateEndpoint.properties.customDnsConfigs[0].ipAddresses[0]
      }
    ]
  }
}

resource privateDNSRecordSetScm 'Microsoft.Network/privateDnsZones/A@2020-06-01' = {
  name: '${appName}.scm'
  parent: privateDNSZone
  properties: {
    ttl: 3600
    aRecords: [
      {
        ipv4Address: privateEndpoint.properties.customDnsConfigs[0].ipAddresses[0]
      }
    ]
  }
}

