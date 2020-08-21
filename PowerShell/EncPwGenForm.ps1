Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$dir = "C:\temp"
if (!(Test-Path $dir))
{
    New-Item -ItemType directory -Path $dir
    Write-Host "Created folder"
}
else 
{
    Write-Host "Folder exists"
}
Do{
    $form = New-Object System.Windows.Forms.Form
    $form.Text = 'Mail Server Pwd Creation Tool'
    $form.Size = New-Object System.Drawing.Size(300,300)
    $form.StartPosition = 'CenterScreen'

    $okButton = New-Object System.Windows.Forms.Button
    $okButton.Location = New-Object System.Drawing.Point(75,200)
    $okButton.Size = New-Object System.Drawing.Size(75,23)
    $okButton.Text = 'OK'
    $okButton.DialogResult = [System.Windows.Forms.DialogResult]::OK
    $form.AcceptButton = $okButton
    $form.Controls.Add($okButton)

    $cancelButton = New-Object System.Windows.Forms.Button
    $cancelButton.Location = New-Object System.Drawing.Point(150,200)
    $cancelButton.Size = New-Object System.Drawing.Size(75,23)
    $cancelButton.Text = 'Cancel'
    $cancelButton.DialogResult = [System.Windows.Forms.DialogResult]::Cancel
    $form.CancelButton = $cancelButton
    $form.Controls.Add($cancelButton)

    $userLabel = New-Object System.Windows.Forms.Label
    $userLabel.Location = New-Object System.Drawing.Point(10,20)
    $userLabel.Size = New-Object System.Drawing.Size(280,20)
    $userLabel.Text = 'Please enter SM username below:'
    $form.Controls.Add($userLabel)

    $userTextBox = New-Object System.Windows.Forms.TextBox
    $userTextBox.Location = New-Object System.Drawing.Point(10,40)
    $userTextBox.Size = New-Object System.Drawing.Size(260,20)
    $form.Controls.Add($userTextBox)

    $passLabel = New-Object System.Windows.Forms.Label
    $passLabel.Location = New-Object System.Drawing.Point(10,60)
    $passLabel.Size = New-Object System.Drawing.Size(280,20)
    $passLabel.Text = 'Please enter SM password below:'
    $form.Controls.Add($passLabel)

    $passTextBox = New-Object System.Windows.Forms.TextBox
    $passTextBox.Location = New-Object System.Drawing.Point(10,80)
    $passTextBox.Size = New-Object System.Drawing.Size(260,20)
    $form.Controls.Add($passTextBox)

    # Using URL to set filename instead

    #$serverNameLabel = New-Object System.Windows.Forms.Label
    #$serverNameLabel.Location = New-Object System.Drawing.Point(10,100)
    #$serverNameLabel.Size = New-Object System.Drawing.Size(280,20)
    #$serverNameLabel.Text = 'Please enter SM ServerName below:'
    #$form.Controls.Add($serverNameLabel)

    #$serverNameTextBox = New-Object System.Windows.Forms.TextBox
    #$serverNameTextBox.Location = New-Object System.Drawing.Point(10,120)
    #$serverNameTextBox.Size = New-Object System.Drawing.Size(260,20)
    #$form.Controls.Add($serverNameTextBox)

    $urlLabel = New-Object System.Windows.Forms.Label
    $urlLabel.Location = New-Object System.Drawing.Point(10,140)
    $urlLabel.Size = New-Object System.Drawing.Size(280,20)
    $urlLabel.Text = 'Please enter SM URL below (no http:// or https://):'
    $form.Controls.Add($urlLabel)

    $urlTextBox = New-Object System.Windows.Forms.TextBox
    $urlTextBox.Location = New-Object System.Drawing.Point(10,160)
    $urlTextBox.Size = New-Object System.Drawing.Size(260,20)
    $form.Controls.Add($urlTextBox)
    $form.Topmost = $true

    $form.Add_Shown({$textBox.Select()})
    $result = $form.ShowDialog()

    if ($result -eq [System.Windows.Forms.DialogResult]::OK)
    {
        $username = $userTextBox.Text
        $password = $passTextBox.Text
        $servername = $serverNameTextBox.Text
        $URL = $urlTextBox.Text

        # PROCESS server information

        $secureStringPwd = $password | ConvertTo-SecureString -AsPlainText -Force
        $creds = New-Object System.Management.Automation.PSCredential -ArgumentList $username, $secureStringPwd
        $secureStringText = $secureStringPwd | ConvertFrom-SecureString
        Set-Content "C:\temp\$URL.txt" $secureStringText
    
    }
} until ($result -eq [System.Windows.Forms.DialogResult]::Cancel)