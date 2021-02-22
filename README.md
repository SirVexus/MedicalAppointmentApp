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
adsdasdasda
* Ekran administratora - pozwala na dodanie nowego regionu, nowego lekarza wraz z przypisaniem go do dodanego wcześniej regionu lun nowego klienta.
fsafsafsa
* Ekran nowej wizyty - umawia się za jego pomocą konkretne wizyty porzez parowanie ze sobą lekarzy, pacjentów, lokacji i godziny, aplikacja filtruje lekarzy według wybranego regionu co nie pozwala na przypisanie lekarzowi wizyty w regionie, który nie jest jego miejscem pracy.
![medicalScreenA](https://user-images.githubusercontent.com/48628436/108748881-64d4f700-753f-11eb-87da-8f3e5078a757.jpg)
* Ekran wizyt pacjentów - wyświetla listę wizyt dla wybranego pacjenta
fsafas
* Ekran wizyt lekarzy - wyświetla listę wizyt dla wybranego lekarza

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
