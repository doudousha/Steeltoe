
# 注意： 请放入".sln"同目录下

$ipAddress = Get-NetIPAddress -AddressFamily ipV4 | where {$_.AddressState -eq "Preferred" }
$xmlFileName = (Get-Location).ToString() + "\.vs\config\applicationhost.config"
$xmlConfig =[xml]( get-content -Path $xmlFileName)
$projectName = ( Get-Item (Get-Location).ToString()).Name 

$site =$xmlConfig.configuration["system.applicationHost"]["sites"].site  | where {$_.name -eq $projectName }

$attrSource = $site.bindings.ChildNodes[0].GetAttribute("bindingInformation")
$attrSource


# Create new node:
$bindingResults = @()
foreach($item in  $ipAddress ){

    $binding = $xmlConfig.CreateElement("binding")
    $binding.SetAttribute("protocol","http")
    $binding.SetAttribute("bindingInformation",$attrSource.Replace("localhost",$item.IPAddress))
    $bindingResults+=$binding
}

 # Write nodes in XML:
foreach($item in $bindingResults){
   # 注意： 这里一定要用@ ，如果集合查询期望是返回1，但是这里返回空字符串。加上@就正常了
  $count = @( $site.bindings.ChildNodes | where {$_.GetAttribute("bindingInformation") -eq $item.GetAttribute("bindingInformation") } ).Count 
  # 小于1
  if($count -lt 1 ){
    $site.bindings.AppendChild($item)
    write-host "增加: $($item.GetAttribute("bindingInformation").ToString() )" 
  }
}

$xmlConfig.Save($xmlFileName)
write-host "修改成功"