<h3>Dodawanie użytkownika</h3>

<style>
    .form-container {
        display: flex;
        flex-direction: column
    }

    .form-group {
        display: flex;
        align-items: center; 
    }

    .form-group > label {
        flex-basis: 20%;
        text-align: right;
        margin-right: 10px;
    }

    .form-group > input,
    .form-group > textarea {
        flex-basis: 80%;
    }
</style>

    <form action="{{route('products.store')}}" method="post" class="form-container">
        @csrf
        <div class="form-group">
            <label for="name">Nazwa produktu</label>
            <input type="text" name="name" id="name" value="{{old('name')}}" autofocus class="form-row"><br><br>
            @error('name')
                <div>{{$message}}</div>
            @enderror
        </div>
        <div class="form-group">
            <label for="price">Cena</label>
            <input type="number" name="price" id="price" value="{{old('name')}}"><br><br>
            @error('price')
                <div>{{$message}}</div>
            @enderror
        </div>
        <div class="form-group">
            <label for="description">Opis produktu</label>
            <textarea name="description" id="description" cols="30" rows="10">{{old('description')}}</textarea>
            @error('description')
                <div>{{$message}}</div>
            @enderror
        </div>
        <div class="form-group">
            <button type="submit">Dodaj użytkownika</button>
        </div>
    </form>
