<!doctype html>
<html lang=pl>
<head>
  <meta charset="UTF-8">
  <meta name="viewport"
        content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
  <meta http-equiv="X-UA-Compatible" content="ie=edge">
  <title>Document</title>
</head>
<body>
<form action="{{ route('articles.store') }}" method="post">
  @csrf
  <div>
    <label for="title">Tytuł:</label>
    <input type="text" name="title" required><br><br>
  </div>
  <div>
    <label for="body">Treść:</label>
    <textarea name="body" cols="30" rows="10" required></textarea>
  </div>
  <button type="submit">Dodaj artykuł</button>
</form>
</body>
</html>
