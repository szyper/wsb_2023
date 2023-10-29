<!doctype html>
<html lang="pl">
<head>
  <meta charset="UTF-8">
  <meta name="viewport"
        content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
  <meta http-equiv="X-UA-Compatible" content="ie=edge">
  <link rel="stylesheet" href="{{ asset('css\style.css') }}">
  <title>Samochody</title>
</head>
<body>
<h3>Samochody</h3>
{{--{{ print_r($cars) }}--}}
{{--{{ print_r($result) }}--}}

@if($result['result'])
  {{ $result['result'] }}<br><br>
@endif

<table class="table">
  <thead>
    <tr>
      <th>Marka</th>
      <th>Model</th>
      <th>Pojemność</th>
    </tr>
  </thead>
  <tbody>
    @foreach($result['cars'] as $car)
      <tr>
        <td>{{ $car->brand }}</td>
        <td>{{ $car->model }}</td>
        <td>{{ $car->capacity }}</td>
      </tr>
    @endforeach
  </tbody>
</table>
{{ $result['cars']->links('pagination::bootstrap-5') }}
</body>
</html>
