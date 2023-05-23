
Set-ExecutionPolicy RemoteSigned -Scope CurrentUser

Clear-Host


Function HelloWorld
{
	Param ($path)
	$path = Get-Location
	Write-Host "hello-world"
	#Write-Host "Command : " $MyInvocation.MyCommand
	$target_folder = Split-Path -leaf -path ($path)
	#Write-Host "File : " $target_folder

	#powershell.exe -executionpolicy bypass -file executer.ps1
	#Invoke-item C:\Windows\System32\notepad.exe
	try
	{
		$Win = $Host.Ui.RawUI.WindowSize
		$Win.Height = 40
		$Win.Width = 50
		$Host.Ui.RawUI.set_windowsize($Win)



		cd .\$target_folder\bin\Debug\	# 3번

		$dotnet_version =  get-childitem

		#Write-Host $dotnet_version

		cd $dotnet_version	# 1번

		$target_items = get-childitem	# 배열로 만들어짐
		
		#Write-Host $target_items

		foreach ($item in $target_items)
		{
			#Write-Host $item # 항상 마지막 (맨 위) 것이 나옴

			#Write-Host $item.split(".")[1]
			if ($item.ToCharArray() -contains $target_folder+".exe")
			{
				#.\*.exe
				$Command = ".\"+$target_folder+".exe"
				Invoke-Expression $Command	# IEX $Command
			}
			else
			{
				Write-Host "Not Found"
			}
		}
		

		
	}
	Catch{}
	Finally{cd ..\..\..\..} # 4번
}

Function setAutoPath
{	
	$target_folder = Split-Path -leaf -path (Get-Location)
	Write-Host  $target_folder
	$move_path = "$target_folder\bin\Debug"

	cd $move_path
	$path_length = $move_path.split("\").count

	Write-Host "경로 수 : " $path_length

	$dotnet_version =  get-childitem

	cd $dotnet_version	

	for( $i=0; $i -lt $path_length + 1; $i++ )	# -little than 왼쪽이 더 작음
	{
		#Write-Host "i : " $i
		cd ..
	}

	Write-Host "Back to Workplace"
}

#HelloWorld
setAutoPath

pause