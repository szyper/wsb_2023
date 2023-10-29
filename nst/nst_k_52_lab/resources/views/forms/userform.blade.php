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
@if(session('result'))
  {{ session('result') }}
@endif
<h3>Dodaj użytkownika</h3>
<form action="AddUserForm" method="post">
  @csrf
  <input type="text" name="brand" placeholder="Dodaj markę" value="{{ old('brand') }}" autofocus>
  @error('brand')
    {{ $message }}
  @enderror<br><br>
  <input type="text" name="model" placeholder="Dodaj model" value="{{ old('model') }}">
  @error('model')
  {{ $message }}
  @enderror<br><br>
  <input type="number" name="capacity" placeholder="Dodaj pojemność" value="{{ old('capacity') }}">
  @error('capacity')
  {{ $message }}
  @enderror<br><br>
  <input type="submit" value="Dodaj użytkownika">
</form>
</body>
</html>
