Imports System
Imports System.IO

Module Program
    Sub Main(args As String())
        Dim file As System.IO.FileStream

        Dim tur As String
        Console.WriteLine("Gerekli Paketler Kuruluyor (Sudo yetkilendirmesini yapman�z gerekiyor)")
        Dim proc = Process.Start("sudo", "apt install -y tar zip shc")
        proc.WaitForExit()
baslangic: Console.Clear()
        Console.WriteLine("DOTNETPKG 0.3 --- .Net Core Linux Projeleri ��in Paketleyici")
        Console.WriteLine("TELEGRAM KANALI: t.me/overclickofficial")
        Console.WriteLine("TELEGRAM GRUBU: t.me/sonbetik")
        Console.WriteLine("-------PROGRAM SADECE DEBIAN TABANLI DISTROLAR VE NET CORE 3.1 ICINDIR!-------")
        Console.WriteLine("Dotnet Uygulaman�z� S�k��t�r�r ve Kullan�c�n�n Dotneti Kolayca Kurabilmesi i�in Bir Bash Dosyas� Ekler Bu Sayede Framework Ba��ml� .Net Core Uygulamalar�n� Rahat�a Da��tabilirsiniz" & vbCrLf)

d�n1:   Console.WriteLine("Dosya T�r�n� Se�in:(1-TAR , 2-ZIP)")
        Dim dt = Console.ReadLine
        If dt = "1" Then
d�n2:       tur = "tar"
            Console.WriteLine("Klas�r Yolunu Belirtin(Ex: /home/xxx/folder):")
            Dim oku = Console.ReadLine
            If Directory.Exists(oku) = False Then
                Console.WriteLine("Klas�r Bulunamad�" & vbCrLf)
                GoTo d�n2
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
d�n3:       tur = "zip"
            Console.WriteLine("Klas�r Yolunu Belirtin(Ex: /home/xxx/folder):")
            Dim oku = Console.ReadLine
            If Directory.Exists(oku) = False Then
                Console.WriteLine("Klas�r Bulunamad�" & vbCrLf)
                GoTo d�n2
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
            Console.WriteLine("Hatal� Komut Girdiniz!")
            GoTo d�n1

        End If
        Console.Clear()

        Console.WriteLine("Ba�ka Klas�r Paketleyecekmisiniz(E/H) ? ")
        Dim ok = Console.ReadLine.ToLower
        If ok = "e" Then
            GoTo baslangic

        ElseIf ok = "h" Then
            Console.Clear()
            Console.WriteLine("Dotnet Kurucusu ""Prepare"" Dosyas� Ar�ivinize Eklendi ./prepare yaparak Kullan�c�lar�n Dotnet 3.1 Kurmas�n� Sa�layabilirsiniz")
            Environment.Exit(0)

        End If
    End Sub
End Module
