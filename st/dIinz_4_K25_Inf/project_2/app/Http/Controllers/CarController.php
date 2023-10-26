<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class CarController extends Controller
{
    public function ShowCarTable(){
//      $data = DB::table('car')->get();
      $data = DB::table('car')->paginate(2);
      return view('car', ['car' => $data]);
    }

    public function AddCar(Request $req){
      $brand = $req->input('brand');
      $model = $req->input('model');
      $capacity = $req->input('capacity');

      $result = DB::insert('insert into car (brand, model, capacity) values (?, ?, ?)', [$brand, $model, $capacity]);

      if ($result > 0){
        $result = "Rekord został prawidłowo dodany do tabeli car";
        return view('result', ['result' => $result]);
        //return redirect()->back()->with('result', 'Rekord został prawidłowo dodany do tabeli car');
      }else{
        //$result = "Nie udało się dodać rekordu do tabeli car";
        //return view('forms.adduserform', ['result' => $result]);
        return redirect()->back()->with('result', 'Nie udało się dodać rekordu do tabeli car');

      }
    }
}
