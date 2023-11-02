<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Hash;

class AddUserController extends Controller
{
    public function AddUser(Request $req){
      //return $req->input();

      $req->validate([
        'name' => 'required | min:2 | max:30',
        'email' => 'required | min:5 | max:30 | email',
        'pass' => 'required | min:8 | max:30'
      ],
      [
        'name.required' => 'Wypełnij pole :attribute',
        'name.min' => 'Pole :attribute musi mieć minimum :min znaków',
        'name.max' => 'Pole :attribute musi mieć minimum :max znaków',
        'email.required' => 'Wypełnij pole :attribute',
        'email.min' => 'Pole :attribute musi mieć minimum :min znaków',
        'email.max' => 'Pole :attribute musi mieć minimum :max znaków',
        'email.email' => 'Pole :attribute musi być typu email',
        'pass.required' => 'Wypełnij pole :attribute',
        'pass.min' => 'Pole :attribute musi mieć minimum :min znaków',
        'pass.max' => 'Pole :attribute musi mieć minimum :max znaków',
      ]);

      $name = $req->input('name');
      $email = $req->input('email');
      $pass = $req->input('pass');
      if (DB::insert('insert into users (name, email, password, created_at, updated_at) values (?, ?, ?, ?, ?)', [$name, $email, Hash::make($pass), now(), now()])){
        $users = DB::table('users')->select('name', 'email', 'password', 'created_at')->paginate(5);
        $result = [
          'result' => "Prawidłowo dodano użytkownika $name do tabeli users",
          'users' => $users
        ];
        return view('users', ['result' => $result]);
      }else{
        return redirect()->back()->with('result', 'Nie udało się dodać rekordu do tabeli users');
      }

    }
}
