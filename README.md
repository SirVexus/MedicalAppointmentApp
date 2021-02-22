# Medical Appointment Manager
Aplikacja do umawiania i zarządzania wizytami medycznymi.

# Wstęp
Medical Appointment Manager jest aplikacją odpowiedzialną za przechowywanie danych przechodni w lokalnej bazie za pomocą przygotowanej do tego windowsowej aplikacji. Posiada ona własną bazę danych w technologii SQLite dzięki czemu działa bez dostępu do internetu. Oprócz opcji dodawania pracowników, klientów i oddziałów, posiada ona też opcje filtrowania wyników, co ułatwia zarządzanie i wyświetlanie tych danych.

# Opis
### Testy
Ze względu na hermetyczną strukturę poszczególnych stron, testy nie są wymagane
### Specyfikacja Techniczna
Opis klas publicznych poszczególnych stron znajduje się [tutaj](https://github.com/SirVexus/MedicalAppointmentApp/blob/main/MedicalAppointmentApp.xml)
### Specyfikacja Wizualna
Aplikacja składa się z następujących stron:
* Wybór opcji - użytkownik może przejść do ekranu administratora w celu dodania nowych danych oraz wyświetlić istniejące z filterowaniem według klientów lub lekarzy.

![medicalScreenC](https://user-images.githubusercontent.com/48628436/108749309-f2184b80-753f-11eb-9c62-a8d7e0b44b87.jpg)
* Ekran administratora - pozwala na dodanie nowego regionu, nowego lekarza wraz z przypisaniem go do dodanego wcześniej regionu lub nowego klienta.

![medicalScreenB](https://user-images.githubusercontent.com/48628436/108749159-c2694380-753f-11eb-9d26-059694049ed5.jpg)
* Ekran nowej wizyty - umawia się za jego pomocą konkretne wizyty porzez parowanie ze sobą lekarzy, pacjentów, lokacji i godziny, aplikacja filtruje lekarzy według wybranego regionu co nie pozwala na przypisanie lekarzowi wizyty w regionie, który nie jest jego miejscem pracy.

![medicalScreenA](https://user-images.githubusercontent.com/48628436/108749004-88983d00-753f-11eb-9ccd-5b746ff55d02.jpg)
* Ekran wizyt pacjentów - wyświetla listę wizyt dla wybranego pacjenta

![medicalScreenE](https://user-images.githubusercontent.com/48628436/108749629-56d3a600-7540-11eb-94f6-53689a223128.jpg)
* Ekran wizyt lekarzy - wyświetla listę wizyt dla wybranego lekarza

* ![medicalScreenD](https://user-images.githubusercontent.com/48628436/108749482-255ada80-7540-11eb-9ac4-73e69baea3a7.jpg)

# Instalacja
Włączenie aplikacji:
### Wersja Developerska
By właczyć aplikację w trybie debugowania otwórz plik MedicalAppointmentApp.sln za pomocą Visual Studio, a następnie wybierz opcję debuguj
### Wersja Produkcyjna
By włączyć aplilkację w wersji produkcyjnej zainstaluj aplikację za pomocą [instalatora](https://github.com/SirVexus/MedicalAppointmentApp/raw/main/Medical%20Appointments%20Manager%20Installer.exe), a następnie kliknij dwukrotnie utworzony skrót. **UWAGA Aplikacja tworzy jednorazowo lokalnie bazę danych, więc nie zaleca się instalowania jej w lokacjach wymagających szczególnych uprawnień, np. partycja systemowa**

# Technologie
Wykorzystane technologie:
* C# 8
* .Net Core 3.1
* WPF Application
* Entity Framework 6
* Entity Framework Core
* Linq
* SQLite
* Data Annotations

# Inne
### Zgłaszanie błędów
Problemy z aplikacją proszę zgłaszać [tutaj](https://github.com/SirVexus/MedicalAppointmentApp/issues)
### Licencja
Aplikacja jest udostępniona na zasadach [GNU - GENERAL PUBLIC LICENSE](https://github.com/SirVexus/MedicalAppointmentApp/blob/main/LICENSE)
### Kontakt
W razie pytań zapraszam do [kontaktu](https://github.com/SirVexus)
