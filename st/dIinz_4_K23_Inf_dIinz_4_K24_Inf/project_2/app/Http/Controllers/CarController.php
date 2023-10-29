<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class CarController extends Controller
{
    public function ShowCarTable(){
//      $data = DB::table('car')->get();
      $data = DB::table('car')->paginate(3);
      //print_r($data);
      return view('car', ['car' => $data]);
    }

    public function AddUser(Request $req){
      //return $req->input();
      $brand = $req->input('brand');
      $model = $req->input('model');
      $capacity = $req->input('capacity');

      $result = DB::insert('insert into car (brand, model, capacity) values (?, ?, ?)', [$brand, $model, $capacity]);
      if ($result > 0){
        return 'Dodano rekord do tabeli car';
      }else{
        //return 'Nie udało się dodać rekordu do tabeli car';
        return redirect()->back()->with('result', 'Nie udało się dodać rekordu');
      }
    }
}
