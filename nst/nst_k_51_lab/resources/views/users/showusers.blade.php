<!doctype html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport"
        content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
  <meta http-equiv="X-UA-Compatible" content="ie=edge">
  <title>Document</title>
</head>
<body>
  <h3>Dane użytkwonika</h3>
  Tablia: <?php print_r($users) ?><br>
  Imię: {{$users[0]->firstName}}<br>
  Nazwisko: {{$users[0]->lastName}}<br>
  Data urodzenia: {{$users[0]->birthday}}

</body>
</html>
