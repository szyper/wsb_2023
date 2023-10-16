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
    <ul>
      @foreach($errors->all() as $error)
        <li>{{$error}}</li>
      @endforeach
    </ul>

  @endif
  <form action="UserController" method="post">
    @csrf
    <input type="text" name="firstName" placeholder="Podaj imię" value="{{old('firstName')}}" autofocus>@error('firstName') {{$message}} @enderror<br><br>
    <input type="email" name="email" placeholder="Podaj email" value="{{old('email')}}">@error('email') {{$message}} @enderror<br><br>
    <input type="password" name="pass" placeholder="Podaj hasło">@error('pass') {{$message}} @enderror<br><br>
    <input type="password" name="pass_confirmation" placeholder="Powtórz hasło">@error('pass_confirmation') {{$message}} @enderror<br><br>
    <input type="submit" value="Zatwierdź">
  </form>
</body>
</html>
