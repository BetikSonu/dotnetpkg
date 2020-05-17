Imports System
Imports System.IO

Module Program
    Sub Main(args As String())
        Dim file As System.IO.FileStream

        Dim tur As String
        Console.WriteLine("Gerekli Paketler Kuruluyor (Sudo yetkilendirmesini yapmanýz gerekiyor)")
        Dim proc = Process.Start("sudo", "apt install -y tar zip shc")
        proc.WaitForExit()
baslangic: Console.Clear()
        Console.WriteLine("DOTNETPKG 0.3 --- .Net Core Linux Projeleri Ýçin Paketleyici")
        Console.WriteLine("TELEGRAM KANALI: t.me/overclickofficial")
        Console.WriteLine("TELEGRAM GRUBU: t.me/sonbetik")
        Console.WriteLine("-------PROGRAM SADECE DEBIAN TABANLI DISTROLAR VE NET CORE 3.1 ICINDIR!-------")
        Console.WriteLine("Dotnet Uygulamanýzý Sýkýþtýrýr ve Kullanýcýnýn Dotneti Kolayca Kurabilmesi için Bir Bash Dosyasý Ekler Bu Sayede Framework Baðýmlý .Net Core Uygulamalarýný Rahatça Daðýtabilirsiniz" & vbCrLf)

dön1:   Console.WriteLine("Dosya Türünü Seçin:(1-TAR , 2-ZIP)")
        Dim dt = Console.ReadLine
        If dt = "1" Then
dön2:       tur = "tar"
            Console.WriteLine("Klasör Yolunu Belirtin(Ex: /home/xxx/folder):")
            Dim oku = Console.ReadLine
            If Directory.Exists(oku) = False Then
                Console.WriteLine("Klasör Bulunamadý" & vbCrLf)
                GoTo dön2
            ElseIf Directory.Exists(oku) = True Then
                file = System.IO.File.Create("prepare.sh")
                file.Close()
                Dim addInfo As New System.IO.StreamWriter("prepare.sh")

                addInfo.WriteLine("#!/bin/bash")
                addInfo.WriteLine("wget ""https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb"" -O packages-microsoft-prod.deb")
                addInfo.WriteLine("sudo dpkg -i packages-microsoft-prod.deb")
                addInfo.WriteLine("sudo apt update")
                addInfo.WriteLine("sudo apt-get install apt-transport-https -y")
                addInfo.WriteLine("sudo apt-get install dotnet-sdk-3.1")
                addInfo.WriteLine("sudo rm -rf packages-microsoft-prod.deb")
                addInfo.WriteLine("clear")
                addInfo.Close()
                Dim prc = Process.Start("shc", "-f prepare.sh")
                prc.WaitForExit()
                Console.Clear()

                Dim proc88 = Process.Start("mv", "prepare.sh.x " & oku & "/prepare")
                proc88.WaitForExit()

                Dim proc87 = Process.Start("rm", "-rf prepare.sh.x.c prepare.sh")
                proc87.WaitForExit()
                Console.Clear()

                Dim proc2 = Process.Start("tar", "cvzf package.tar.gz " & oku)
                proc2.WaitForExit()
                Console.Clear()

            End If

        ElseIf dt = "2" Then
dön3:       tur = "zip"
            Console.WriteLine("Klasör Yolunu Belirtin(Ex: /home/xxx/folder):")
            Dim oku = Console.ReadLine
            If Directory.Exists(oku) = False Then
                Console.WriteLine("Klasör Bulunamadý" & vbCrLf)
                GoTo dön2
            ElseIf Directory.Exists(oku) = True Then
                file = System.IO.File.Create("prepare.sh")
                file.Close()
                Dim addInfo As New System.IO.StreamWriter("prepare.sh")

                addInfo.WriteLine("#!/bin/bash")
                addInfo.WriteLine("wget ""https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb"" -O packages-microsoft-prod.deb")
                addInfo.WriteLine("sudo dpkg -i packages-microsoft-prod.deb")
                addInfo.WriteLine("sudo apt update")
                addInfo.WriteLine("sudo apt-get install apt-transport-https -y")
                addInfo.WriteLine("sudo apt-get install dotnet-sdk-3.1")
                addInfo.WriteLine("sudo rm -rf packages-microsoft-prod.deb")
                addInfo.WriteLine("clear")
                addInfo.Close()
                Dim prc = Process.Start("shc", "-f prepare.sh")
                prc.WaitForExit()
                Console.Clear()

                Dim proc88 = Process.Start("mv", "prepare.sh.x " & oku & "/prepare")
                proc88.WaitForExit()

                Dim proc87 = Process.Start("rm", "-rf prepare.sh.x.c prepare.sh")
                proc87.WaitForExit()
                Console.Clear()

                Dim proc2 = Process.Start("zip", "-r package.zip " & oku)
                proc2.WaitForExit()
                Console.Clear()



            End If

        Else
            Console.WriteLine("Hatalý Komut Girdiniz!")
            GoTo dön1

        End If
        Console.Clear()

        Console.WriteLine("Baþka Klasör Paketleyecekmisiniz(E/H) ? ")
        Dim ok = Console.ReadLine.ToLower
        If ok = "e" Then
            GoTo baslangic

        ElseIf ok = "h" Then
            Console.Clear()
            Console.WriteLine("Dotnet Kurucusu ""Prepare"" Dosyasý Arþivinize Eklendi ./prepare yaparak Kullanýcýlarýn Dotnet 3.1 Kurmasýný Saðlayabilirsiniz")
            Environment.Exit(0)

        End If
    End Sub
End Module
