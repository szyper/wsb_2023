<!doctype html>
<html lang="pl">
<head>
  <meta charset="UTF-8">
  <meta name="viewport"
        content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
  <meta http-equiv="X-UA-Compatible" content="ie=edge">
  <link rel="stylesheet" href="{{ asset('css\style.css') }}">
  <title>Użytkownicy</title>
</head>
<body>
<h3>Użytkownicy</h3>
{{--{{ print_r($result) }}--}}
<table>
  <thead>
    <tr>
      <th>Nazwa użytwkonika</th>
      <th>Email</th>
      <th>Hasło</th>
      <th>Data utworzenia</th>
    </tr>
  </thead>
  <tbody>
    @foreach($result['users'] as $user)
      <tr>
        <td>{{ $user->name }}</td>
        <td>{{ $user->email }}</td>
        <td>{{ $user->password }}</td>
        <td>{{ $user->created_at }}</td>
      </tr>
    @endforeach
  </tbody>
</table>
{{ $result['users']->links('pagination::bootstrap-5') }}
</body>
</html>
