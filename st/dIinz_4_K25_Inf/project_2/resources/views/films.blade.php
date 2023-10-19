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
  <h3>Filmy</h3>
  <ul>
{{--    {{print_r($films)}}--}}
    @foreach($films as $film)
      <li>{{$film}}</li>
    @endforeach
  </ul>
</body>
</html>
