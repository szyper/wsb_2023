<h3>Dodawanie użytkownika</h3>
<div>
    <form action="{{route('products.store')}}" method="post">
        @csrf
        <div>
            <label for="name">Nazwa produktu</label>
            <input type="text" name="name" id="name" value="{{old('name')}}">
        </div>
        <div>
            <label for="name">Cena produktu</label>
            <input type="number" name="price" id="price" value="{{old('price')}}">
        </div>
        <div>
            <label for="name">Opis produktu</label>
            <textarea name="description" id="description" cols="30" rows="10">{{old('description')}}</textarea>
        </div>
        <div>
            <button type="submit">zapisz</button>
        </div>
    </form>
</div>
