<h3>Aktualizacja użytkownika</h3>
<div>
    <form action="{{route('products.update', $product->id)}}" method="POST">
        @csrf
        @method('PUT')
        <div>
            <label for="name">Nazwa produktu</label>
            <input type="text" name="name" id="name" value="{{$product->name}}">
        </div>
        <div>
            <label for="name">Cena produktu</label>
            <input type="number" name="price" id="price" value="{{$product->price}}">
        </div>
        <div>
            <label for="name">Opis produktu</label>
            <textarea name="description" id="description" cols="30" rows="10">{{$product->description}}</textarea>
        </div>
        <div>
            <button type="submit">zapisz</button>
        </div>
    </form>
</div>
