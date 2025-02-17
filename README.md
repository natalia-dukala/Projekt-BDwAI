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

4) Aktualizacja bazy danych
   - add-migration "nazwa migarcji"
   - update-database

3) Użytkownicy:</br></br>
   &rarr;&nbsp;Administrator  
       &nbsp;&nbsp;login: admin@example.com  
       &nbsp;&nbsp;hasło: Admin123!</br></br>
   &rarr;&nbsp;Zwykli użytkownicy  
      &nbsp;login: user@example.com  
      &nbsp;hasło: User123!</br></br>
      &nbsp;Do dodawania zwykłych użytkowników należy użyć opcji "Register".  
      &nbsp;Najlepiej dodać jeszcze conajmniej jednego (poza powyższym seedowanym), aby zobaczyć pełną funkcjonalność aplikacji.

5) Działanie aplikacji (dostęp do widoków):</br></br>
   &rarr;&nbsp;Użytkownik niezalogowany:
   - Home oraz Privacy - defaultowe strony MVC
   - Hotels - dostęp do listy hoteli oraz listy pokoi w tych hotelach (Details); brak możliwości rezerwacji pokoju
   - Przycisk Regiter - przenosi do formularza rejestracyjnego
   - Przycisk Login - przenosi do formularza logowania

   &rarr;&nbsp;Użytkownik zalogowany:
   - Home oraz Privacy - defaultowe strony MVC
   - Hotels - dostęp do listy hoteli (tak jak w przypadku niezalogowanego użytkowanika), do listy pokoi (Details); możliwość dokonania rezerwacji konkretnego pokoju - przekierowanie do formularza oraz anulowania rezerwacji (leśli taka została wykonana)
   - Your reservations - lista rezerwacji danego zalogowanego użytkownika
   - Przycisk Logout - wylogowuje użytkowanika

   &rarr;&nbsp;Administrator:
   - Home oraz Privacy - defaultowe strony MVC
   - Hotels - admin ma dostęp do listy hoteli, ich edycji, usuwania, details (lista pokoi - również możliwość edycji oraz usuwania, ale brak opcji rezerwacji); uprawnienia do dodawania nowych hoteli i pokoi - formularze
   - All reservations - lista wszystkich wykonanych rezerwacji
   - Categories - lista kategorii hoteli, możliwość edycji, usuwania, dodawania nowych kategorii (formularz)
   - Przycisk Logout - wylogowuje admina
