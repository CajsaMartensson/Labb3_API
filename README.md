Hämta alla personer i systemet: https://localhost:7000/api/App/persons

Hämta alla intressen i systemet: https://localhost:7000/api/App/interests

Hämta alla intressen kopplade till en specifik person: https://localhost:7000/api/App/persons/4/interests (Hämtar alla intressen för person med id 4)

Hämta alla länkar kopplade till en specifik person: https://localhost:7000/api/App/getPersonLinkById/persons/3 (Hämtar länkar för person som har id 3)

Koppla en person till ett nytt intresse: https://localhost:7000/api/App/addInterest/person/2/interest/5 (Lägger till intresse med id 5, hos personen med id 2)

Lägga till ny länk för en specifik person och ett specifikt intresse: https://localhost:7000/api/App/addLinkToPersonInterest/persons/3}/interest/6 (Lägger till länk till person med id 3 och intresse med id 6)
