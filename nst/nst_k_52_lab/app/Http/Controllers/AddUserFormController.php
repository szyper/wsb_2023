<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class AddUserFormController extends Controller
{
  public function AddCar(Request $req){

    $req->validate([
      'brand' => 'required | min:2 | max:30',
      'model' => 'required | min:2 | max:30',
      'capacity' => 'required | min:3 | max:30'
    ],
    [
      'brand.required' => 'Wypełnij pole :attribute',
      'brand.min' => 'Pole :attribute musi mieć minimum :min znaków',
      'brand.max' => 'Pole :attribute musi mieć maksimum :max znaków',
      'model.required' => 'Wypełnij pole :attribute',
      'model.min' => 'Pole :attribute musi mieć minimum :min znaków',
      'model.max' => 'Pole :attribute musi mieć maksimum :max znaków',
      'capacity.required' => 'Wypełnij pole :attribute',
    ]);

    $brand = $req->input('brand');
    $model = $req->input('model');
    $capacity = $req->input('capacity');

    $result = DB::insert('insert into cars (brand, model, capacity) values (?, ?, ?)', [$brand, $model, $capacity]);

    if ($result == 1){
      //$cars = DB::table('cars')->select('brand', 'model', 'capacity')->get();
      $cars = DB::table('cars')->select('brand', 'model', 'capacity')->paginate(5);
      $result = [
        'result' => 'Rekord został prawidłowo dodany do tabeli cars',
        'cars' => $cars
      ];
      return view('users' , ['result' => $result]);
      //return redirect()->back()->with('result', 'Nie udało się dodać rekordu do tabeli cars');
    }else{
      return redirect()->back()->with('result', 'Nie udało się dodać rekordu do tabeli cars');
    }
  }
}
