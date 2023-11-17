<!doctype html>
<html lang="pl">
<head>
  <meta charset="UTF-8">
  <meta name="viewport"
        content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
  <meta http-equiv="X-UA-Compatible" content="ie=edge">
  <title>Artykuły</title>
</head>
<body>
<h3>Artykuły</h3>
<table>
  <thead>
    <tr>
      <th>Tytuł</th>
      <th>Treść</th>
      <th>Data utworzenia</th>
      <th>Data modyfikacji</th>
    </tr>
  </thead>
  <tbody>
    @foreach($articles as $article)
      <tr>
        <td>{{ $article->title }}</td>
        <td>{{ $article->body }}</td>
        <td>{{ $article->created_at }}</td>
        <td>{{ $article->updated_at }}</td>
      </tr>
    @endforeach
  </tbody>
</table>
</body>
</html>
