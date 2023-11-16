<form action="second-page" method="post">
    @csrf
    <input type="text" name="name" autofocus placeholder="Podaj imię"><br><br>
    <input type="email" name="email" placeholder="Podaj email"><br><br>
    <input type="submit" value="Zatwierdź">
</form>
