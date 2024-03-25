Param(
    [parameter(Mandatory=$false)][string]$appName="eshopmicroservice"
    )

function Install-Chart  {
    Param([string]$chart, [string]$initialOptions)
    $options=$initialOptions

    $cmd = "helm install $appName-$chart $chart $options"
    Write-Host "Helm Command: $cmd" -ForegroundColor Gray
    Invoke-Expression $cmd
}


Write-Host "Installation using Helm started" -ForegroundColor Green

$infras = ("basketdb", "catalogdb", "orderdb", "distributedcache", "messagebroker" ,"elasticsearch", "kibana")
$apis = ("catalogapi","discountgrpc", "orderapi", "basketapi", "shoppingweb")
$gateways = ("yarpgateway")


foreach ($infra in $infras) {
    Write-Host "Installing: $infra" -ForegroundColor Green
    Write-Host "$infra"
    Install-Chart $infra
}

foreach ($api in $apis) {
    Write-Host "Installing: $api" -ForegroundColor Green
    Install-Chart $api
}

foreach ($gateway in $gateways) {
    Write-Host "Installing: $gateway" -ForegroundColor Green
    Install-Chart $gateway
}

Write-Host "helm charts installed." -ForegroundColor Green