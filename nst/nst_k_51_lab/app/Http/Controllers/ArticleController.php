<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Article;

class ArticleController extends Controller
{
    public function AddArticle(Request $req){
      //return $req->input();

      $article = new Article();
      $article->title = $req->title;
      $article->body = $req->body;
      $article->save();
    }

    public function EditArticle(Request $req){
      $article = Article::findorfail($req->id);
      $article->title = $req->title;
      $article->body = $req->body;
      $article->update();
    }

    public function DeleteArticle(Request $req)
    {
      $article = Article::where('id', $req->id)->first();
      if ($article){
        Article::findorfail($req->id)->delete();
        $article = Article::where('id', $req->id)->first();
        if (!$article){
          return 'usunięto artykuł';
        }else{
          return 'nie usunięto rekordu';
        }
      }else{
        return 'brak id';
      }



    }
}
