<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Użytkownicy</title>
</head>
<body>
@if($errors->any())
  <ul>
    @foreach($errors->all() as $error)
      <li>
        {{ $error }}
      </li>
    @endforeach
  </ul>
@endif
<form action="FormController" method="post">
  @csrf
  <input type="text" name="firstName" placeholder="Podaj imię" value="{{ old('firstName') }}" autofocus>
  @error('firstName')
  {{ $message }}
  @enderror<br><br>
  <input type="text" name="lastName" placeholder="Podaj imię" value="{{ old('lastName') }}">
  @error('lastName')
  {{ $message }}
  @enderror<br><br>
  <input type="email" name="mail" placeholder="Podaj email" value="{{ old('mail') }}">
  @error('mail')
  {{ $message }}
  @enderror<br><br>
  <input type="email" name="remail" placeholder="Powtórz email" value="{{ old('remail') }}">
  @error('remail')
  {{ $message }}
  @enderror<br><br>
  <input type="submit" value="Wyślij">
</form>
</body>
</html>
