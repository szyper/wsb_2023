<h3>Dodaj produkt</h3>
<div>
  <form action="{{route('products.store')}}" method="post">
    @csrf
    <input type="text" name="name" id="name" value="{{old('name')}}" placeholder="Podaj nazwę produktu" autofocus>
    @error('name')
    {{$message}}
    @enderror<br><br>
    <input type="number" name="price" id="price" value="{{old('price')}}" placeholder="Podaj cenę produktu">
    @error('price')
    {{$message}}
    @enderror<br><br>
    <textarea name="description" id="" cols="30" rows="10" placeholder="Opis ...">{{old('name')}}</textarea><br><br>
    <button type="submit">Dodaj produkt</button>
  </form>
</div>
