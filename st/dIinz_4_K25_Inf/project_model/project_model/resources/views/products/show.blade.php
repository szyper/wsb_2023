<h3>Szczegóły produktu</h3>
<div>
    <p>Nazwa produktu: {{$product->name}}</p>
    <p>Cena produktu: {{$product->price}}</p>
    <p>Opis produktu: {{$product->description}}</p>
    <a href="{{route('products.edit', ['product' => $product])}}">Edytuj</a>
</div>
