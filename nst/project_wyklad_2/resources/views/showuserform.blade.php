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
<h3>Użytkownik</h3>
{{--{{ print_r($user) }}--}}
Imię i nazwisko: {{ $user['firstName'] }} {{ $user['lastName'] }}<br>
Email: {{ $user['mail'] }}
</body>
</html>
