**API**

Hämta alla personer i systemet: https://localhost:7000/api/App/persons

Hämta alla intressen kopplade till en specifik person: https://localhost:7000/api/App/persons/4/interests (Hämtar alla intressen för person med id 4)

Hämta alla länkar kopplade till en specifik person: https://localhost:7000/api/App/getPersonLinkById/persons/3 (Hämtar länkar för person som har id 3)

Koppla en person till ett nytt intresse:
https://localhost:7000/api/App/addInterest/2?interestId=5 (Lägger till intresse med id 5, hos personen med id 2)

Lägga till ny länk för en specifik person och ett specifikt intresse: https://localhost:7000/api/App/addLinkToPersonInterest?userId=3&intrestId=6&url=https%3A%2F%2Fstackoverflow.com%2Fquestions (Lägger till länk (https://stackoverflow.com/questions) till person med id 3 och intresse med id 6)
