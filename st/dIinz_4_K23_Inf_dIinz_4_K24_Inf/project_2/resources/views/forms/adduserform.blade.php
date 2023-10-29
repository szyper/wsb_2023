<!doctype html>
<html lang="pl">
<head>
  <meta charset="UTF-8">
  <meta name="viewport"
        content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
  <meta http-equiv="X-UA-Compatible" content="ie=edge">
  <title>Dodawanie samochodu</title>
</head>
<body>
<h3>Dodawanie samochodu</h3>
<form action="AddUser" method="post">
  @csrf
  <input type="text" name="brand" placeholder="Podaj markę" autofocus><br><br>
  <input type="text" name="model" placeholder="Podaj model"><br><br>
  <input type="number" name="capacity" placeholder="Podaj pojemność"><br><br>
  <input type="submit" value="Dodaj samochód">
</form>
</body>
</html>
