# Dokumentacja projektu zaliczniowego  
z kursu BAZY DANYCH W APLIKACJACH INTERNETOWYCH  
TEMAT: System rezerwacji hoteli  
(https://github.com/natalia-dukala/Projekt-BDwAI)
-

1) Niezbędne pakiety:
   - Microsoft.AspNetCore.Identity.EntityFrameworkCore (9.0.2)
   - Microsoft.AspNetCore.Identity.UI (9.0.0)
   - Microsoft.EntityFrameworkCore (9.0.2)
   - Microsoft.EntityFrameworkCore.Design (9.0.2)
   - Microsoft.EntityFrameworkCore.SqlServer (9.0.2)
   - Microsoft.EntityFrameworkCore.Tools (9.0.2)
   - Microsoft.VisualStudio.Web.CodeGeneration.Core (9.0.0)
   - Microsoft.VisualStudio.Web.CodeGeneration.Design (9.0.0)

2) Konfiguracja połączenia z bazą danych:  
   &rarr;&nbsp;plik appsettings.json  
   "ConnectionStrings": {  
     "DevConnection": "Server=NAZWA_SWOJEGO_SERWERA_SQL;Database=Reservations;Trusted_Connection=True;TrustServerCertificate=True;"  
   }

3) Aktualizacja bazy danych
   - add-migration "nazwa migarcji"
   - update-database

3) Użytkownicy:  
   &rarr;&nbsp;Administrator  
       &nbsp;login: admin@example.com  
       &nbsp;hasło: Admin123!  
   &rarr;&nbsp;Zwykli użytkownicy  
       &nbsp;Aby dodać zwykłych użytkowników należy użyć opcji "Register"  
       &nbsp;Najlepiej dodać conajmniej dwóch, aby zobaczyć pełną funkcjonalność aplikacji

4) Działanie aplikacji (dostęp do widoków):  
   &rarr;&nbsp;Użytkownik niezalogowany:
   - Home oraz Privacy - defaultowe strony MVC
   - Hotels - dostęp do listy hoteli oraz listy pokoi w tych hotelach (Details)
   - Przycisk Regiter - przenosi do formularza rejestracyjnego
   - Przycisk Login - przenosi do formularza logowania

   &rarr;&nbsp;Użytkownik zalogowany:
   - Home oraz Privacy - defaultowe strony MVC
   - Hotels - dostęp do listy hoteli (tak jak w przypadku niezalogowanego użytkowanika), do listy pokoi (Details) oraz możliwości wykonania rezerwacji konkretnego pokoju
   - Your reservations - lista rezerwacji danego zalogowanego użytkownika
   - Przycisk Logout - wylogowuje użytkowanika
   &rarr;&nbsp;Administrator:
   - 
