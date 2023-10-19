<!doctype html>
<html lang="pl">
<head>
  <meta charset="UTF-8">
  <meta name="viewport"
        content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
  <meta http-equiv="X-UA-Compatible" content="ie=edge">
  <link rel="stylesheet" href="{{ asset('css/style.css') }}">
  <title>Użytkownicy</title>
</head>
<body>
{{--  {{print_r($users)}}--}}
<table>
  <tr>
    <th>Imię</th>
    <th>Nazwisko</th>
    <th>Miasto</th>
  </tr>
  @foreach($users as $user)
    <tr>
{{--      {{print_r($user)}}<br>--}}
      <td>{{ $user['firstName'] }}</td>
      <td>{{ $user['lastName'] }}</td>
      <td>{{ $user['city'] }}</td>
    </tr>
  @endforeach
</table>
</body>
</html>
