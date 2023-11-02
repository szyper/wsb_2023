<!doctype html>
<html lang="pl">
<head>
  <meta charset="UTF-8">
  <meta name="viewport"
        content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
  <meta http-equiv="X-UA-Compatible" content="ie=edge">
  <title>Użytkownik</title>
</head>
<body>
<h3>Dane użytkownika</h3>
<form action="AddUserController" method="get">
{{--  @csrf--}}
  <input type="text" name="name" placeholder="Podaj nazwę użytkownika">
  @error('name')
    {{ $message }}
  @enderror<br><br>
  <input type="email" name="email" placeholder="Podaj email użytkownika">
  @error('email')
  {{ $message }}
  @enderror<br><br>
  <input type="password" name="pass" placeholder="Podaj hasło użytkownika">
  @error('pass')
  {{ $message }}
  @enderror<br><br>
  <input type="submit" value="Dodaj użytkownika"><br><br>
</form>
</body>
</html>
