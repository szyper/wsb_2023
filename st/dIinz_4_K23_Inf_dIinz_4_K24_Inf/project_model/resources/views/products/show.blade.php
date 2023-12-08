<h3>Dane użytkownika o id={{$product->id}}</h3>
<div>
    Nazwa produktu: {{$product->name}}<br><br>
    Cena produktu: {{$product->price}}<br><br>
    Opis produktu: {{$product->description}}
    <hr>
    <a href="{{route('products.edit', ['product'=>$product])}}">Edytuj produkt</a>
</div>
