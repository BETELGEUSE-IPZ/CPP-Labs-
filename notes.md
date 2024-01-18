# Пакування nuget пакету
```
dotnet pack -c Release
dotnet nuget push $PATH_TO_FOLDER$\AShvyndia6.1.0.0.nupkg --source "PrivateRepo"
```

# Файл конфігурації Vagrant (Vagrantfile) для Linux
```
Vagrant.configure("2") do |config|

  config.vm.box = "generic/debian10"

  config.vm.network "forwarded_port", guest: 44329, host: 44329
  config.vm.network "forwarded_port", guest: 5000, host: 5000
  config.vm.network "forwarded_port", guest: 5432, host: 5433, host_ip: "127.0.0.1"

  config.vm.provider "virtualbox" do |vb|
     vb.gui = false
     vb.memory = "1024"
  end

  config.vm.provision "shell", inline: <<-SHELL
      sudo apt-get update
      sudo apt-get install -y apt-transport-https

      sudo dpkg --purge packages-microsoft-prod && sudo dpkg -i packages-microsoft-prod.deb
      sudo apt-get update 
      sudo apt-get install -y gpg
      wget -O - https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor -o microsoft.asc.gpg
      sudo mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/
      wget https://packages.microsoft.com/config/ubuntu/20.04/prod.list
      sudo mv prod.list /etc/apt/sources.list.d/microsoft-prod.list
      sudo chown root:root /etc/apt/trusted.gpg.d/microsoft.asc.gpg
      sudo chown root:root /etc/apt/sources.list.d/microsoft-prod.list
      sudo apt-get update && \
      sudo apt-get install -y dotnet-sdk-7.0

      echo 'export PATH=$PATH:$HOME/.dotnet/tools' >> /home/vagrant/.bash_profile
      su - vagrant -c "dotnet nuget add source http://10.0.2.2:44329/nuget"
      su - vagrant -c "dotnet tool install -g AShvyndia6 --version 1.0.0 --ignore-failed-sources"
  SHELL
end
```