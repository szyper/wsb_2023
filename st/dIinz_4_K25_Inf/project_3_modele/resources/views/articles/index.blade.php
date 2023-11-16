<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
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