<!doctype html>
<html lang="pl">
<head>
  <meta charset="UTF-8">
  <meta name="viewport"
        content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
  <meta http-equiv="X-UA-Compatible" content="ie=edge">
  <title>Dane użytkownika</title>
</head>
<body>
  <h3>Dane użytkownika</h3>
  @if($errors->any())
    <p>
      @foreach($errors->all() as $error)
        <li>{{$error}}</li>
      @endforeach
    </p>
  @endif

  <form action="UserController" method="post">
    @csrf
    <input type="text" name="firstName" value="{{old('firstName')}}" placeholder="Podaj imię" autofocus><br><br>
    <input type="text" name="lastName" value="{{old('lastName')}}" placeholder="Podaj nazwisko"><br><br>
    <input type="email" name="email" value="{{old('email')}}" placeholder="Podaj email"><br><br>
    <input type="radio" name="color" value="r" checked>czerwony
    <input type="radio" name="color" value="g">zielony
    <input type="radio" name="color" value="b">niebieski<br><br>
    <input type="submit" value="Wyświetl dane">
  </form>
</body>
</html>
