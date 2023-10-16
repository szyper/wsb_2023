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
  <h3>Użytkownik</h3>
  <form action="UserController" method="post">
    @csrf
    <input type="text" name="firstName" placeholder="Podaj imię" value="{{old('firstName')}}">@error('firstName') {{$message}} @enderror<br><br>
    <input type="email" name="email" placeholder="Podaj email" value="{{old('email')}}">@error('email') {{$message}} @enderror<br><br>
    <input type="password" name="pass" placeholder="Dodaj hasło">@error('pass') {{$message}} @enderror<br><br>
    <input type="password" name="pass_confirmation" placeholder="Dodaj hasło">@error('pass_confirmation') {{$message}} @enderror<br><br>
    <input type="radio" name="gender" value="m" checked value="{{old('gender')}}">Mężczyzna
    <input type="radio" name="gender" value="w" value="{{old('gender')}}">Kobieta
    @error('gender') {{$message}} @enderror<br><br>
    <input type="submit" value="Zatwierdź">
  </form>
</body>
</html>
