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
<form action="AddCarFormController" method="post">
  @csrf
  <input type="text" name="brand" placeholder="Podaj markę samochodu" value="{{ old('brand') }}">
  @error('brand')
    {{ $message }}
  @enderror<br><br>
  <input type="text" name="model" placeholder="Podaj model samochodu" value="{{ old('model') }}">
  @error('model')
  {{ $message }}
  @enderror<br><br>
  <input type="text" name="capacity" placeholder="Podaj pojemność samochodu" value="{{ old('capacity') }}">
  @error('capacity')
  {{ $message }}
  @enderror<br><br>
  <input type="submit" value="Dodaj użytkownika">
</form>
</body>
</html>
