<?php

namespace App\Http\Controllers;

use App\Models\Article;
use Illuminate\Http\Request;

class ArticlesController extends Controller
{
    public function index(){
      $articles = Article::all();

      //print_r($articles);

      return view('articles.index', ['articles' => $articles]);
    }

    public function store(Request $req){
      $article = new Article();
      $article->title = $req->input('title');
      $article->body = $req->input('body');
      $article->save();

      return redirect('articles/index');
    }
}
