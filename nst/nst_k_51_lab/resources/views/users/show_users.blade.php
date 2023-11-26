<div>
    <table>
      <thead>
        <tr>
          <th>Id</th>
          <th>Nazwa</th>
          <th>Email</th>
        </tr>
      </thead>
      <tbody>
        @foreach($users as $user)
          <tr>
            <td>{{ $user->id }}</td>
            <td>{{ $user->name }}</td>
            <td>{{ $user->email }}</td>
          </tr>
        @endforeach
      </tbody>
    </table>
</div>
