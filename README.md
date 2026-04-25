Hämta alla personer i systemet: https://localhost:7000/api/App/persons

Hämta alla intressen i systemet: https://localhost:7000/api/App/interests

Hämta alla intressen kopplade till en specifik person: https://localhost:7000/api/App/persons/4/interests (Hämtar person med id 4)

Hämta alla länkar kopplade till en specifik person: https://localhost:7000/api/App/getPersonLinkById/3 (personId 3)

Koppla en person till ett nytt intresse: https://localhost:7000/api/App/addInterest/person/2/interest/5 (PersonId: 2, InterestId 5)

Lägga till ny länk för en specifik person och ett specifikt intresse: https://localhost:7000/api/App/addLinkToPersonInterest/3/6 (personId 3, IntrestId 6)
