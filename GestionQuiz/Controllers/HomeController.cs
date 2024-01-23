using GestionQuiz.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestionQuiz.Controllers
{
    public class HomeController : Controller
    {
        public readonly QuizExamenContext context;
        public HomeController(QuizExamenContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreerQuiz(string UserName, string Email, string easy, string medium, string hard)
        {
            TempData["Category"] = context.Category.ToList();
            ViewBag.QuizCree = null;
            if (UserName != null && Email != null)
            {
                //Insertion d'un nouveau enregistrement dans Quiz
                Debug.WriteLine("---UserName-- " + UserName);
                Debug.WriteLine("---Email-- " + Email);
                //Chercher le prochain IdQuiz
                //int nextQuizId = context.Quiz.Select(q => q.QuizId).ToList().Max() + 1;
                //Debug.WriteLine("-----------next QuizId---- " + nextQuizId);

                Quiz newQuiz = new Quiz();
                //newQuiz.QuizId = nextQuizId;
                newQuiz.UserName = UserName;
                newQuiz.Email = Email;
                context.Add<Quiz>(newQuiz);
                context.SaveChanges();
                //apres SaveChanges() on trouve QuizId
                int nextQuizId = newQuiz.QuizId;
                ViewBag.quiz = newQuiz;

                Debug.WriteLine("--------Easy------ " + easy);
                Debug.WriteLine("--------Medium------ " + medium);
                Debug.WriteLine("--------Hard------ " + hard);


                List<Category> catagories = context.Category.ToList();
                bool auMoinsUneQuest = false;
                try
                {
                   
                    foreach (Category c in catagories)
                    {
                        Random aleatoire = new Random();
                        Debug.WriteLine("------foreach-----Categorie---- " + c.Description);
                        int nbQuests = 0;
                        if (c.Description == "easy")
                        {
                            nbQuests = (easy != null)? Int32.Parse(easy) : 0;
                        }
                        else if (c.Description == "medium")
                        {
                            nbQuests = (medium != null) ? Int32.Parse(medium) : 0;
                        }
                        else if (c.Description == "hard")
                        {
                            nbQuests = (hard != null) ? Int32.Parse(hard) : 0;
                        }
                        int idQuest = 0;

                        //Chercher le liste des questions de cette categorie
                        List<int> QuestByCateg = context.Question.Where(q => q.CategoryId == c.CategoryId).Select( q => q.QuestionId).ToList();
                        Debug.WriteLine("----totalQuestCateg --  c.Description -- " + QuestByCateg.Count());
                        //Chercher en aleatoire des id questions au Quiz en cours(nombre de questions est easy)
                        List<int> QuestIsList = new List<int>();
                        while (QuestIsList.Count() < nbQuests)
                        {
                            idQuest = QuestByCateg[aleatoire.Next(0, QuestByCateg.Count())];
                            
                            if (QuestIsList.Contains(idQuest) == false)
                            {
                                QuestIsList.Add(idQuest);
                            }
                        }
                        QuestionQuiz newQuestQuiz;
                        foreach (int ident in QuestIsList)
                        {
                            newQuestQuiz = new QuestionQuiz();
                            newQuestQuiz.QuizId = nextQuizId;
                            newQuestQuiz.QuestionId = ident;
                            context.Add<QuestionQuiz>(newQuestQuiz);
                            Debug.WriteLine("nouveau QuestionQuiz:  QuizId  " + nextQuizId + " QuestionId  " + ident);
                            auMoinsUneQuest = true;
                        }
                    }
                    //Insertion des enregistrement correspondants dans la table QuestionQuiz
                    context.SaveChanges(); 
                }
                catch (Exception e)
                {
                    //Supprimer le nouveau quiz newQuiz, car aucun enregistrement QuestionQuiz n'est généré
                    Debug.WriteLine(e.Message);
                    auMoinsUneQuest = false;
                }
                if (!auMoinsUneQuest)
                {
                    //Supprimer le nouveau quiz newQuiz, car aucun enregistrement QuestionQuiz n'est généré
                    context.Remove<Quiz>(newQuiz);
                    context.SaveChanges();
                    ViewBag.QuizCree = false;
                    ViewBag.MsgGenereQuiz = "La génaration d'un nouveau quiz pour l'utilisateur <<"+ newQuiz.UserName+ ">> a échoué!!!!";
                }
                else
                {
                    ViewBag.QuizCree = true;
                    ViewBag.MsgGenereQuiz = "La génaration d'un nouveau quiz (Id <<" + newQuiz.QuizId + ">>) pour l'utilisateur <<" + newQuiz.UserName + ">> est faite avec succès...";
                }
                //return View("Index");

            }
    
             return View();
        }

        public IActionResult AfficherQuizGenerer(string username, string email)
        {
            if (username != null && email != null)
            {

                var quiz = context.Quiz.Where(q => q.UserName == username && q.Email == email).ToList();
                if (quiz.Count > 0)
                {
                    ViewBag.message = username;
                    ViewBag.style = "text-success";
                    return View(quiz);
                }
                else
                {
                    ViewBag.message = "pas de quiz pour l'utilisateur " + username + " et avec l'email " + email;
                    ViewBag.style = "text-danger";
                }
            }
            return View();


        }

        public IActionResult ReviserUnQuiz(string username, string email)
        {
            if (username != null && email != null)
            {
                var quiz = context.Quiz.Where(q => q.UserName == username && q.Email == email && q.Answer != null && q.Answer.Count > 0).ToList();

                Debug.WriteLine(quiz);
                if (quiz.Count > 0)
                {
                    ViewBag.message = username;
                    ViewBag.style = "text-success";
                    return View(quiz);
                }
                else
                {
                    ViewBag.message = "pas de quiz pour l'utilisateur " + username + " et avec l'email " + email;
                    ViewBag.style = "text-danger";
                }
            }
            return View();


        }

        public IActionResult PasserQuizQuestions(int IdQuiz, string UserName)
        {
            Debug.WriteLine("---IdQuiz------ " + IdQuiz + " ------UserName----- " + UserName);

            if ((IdQuiz != 0) && (UserName != null))
            {
                //Recherche pour IdQuiz de toutes les questions avec leurs ItemOptions
                List<int> listIdQuesQuiz = context.QuestionQuiz.Where(q => q.QuizId == IdQuiz).Select(q => q.QuestionId).ToList();
                //Recherche des questions relatives à la liste listIdQuesQuiz
                List<Question> questions = context.Question.Where(q => listIdQuesQuiz.Contains(q.QuestionId)).ToList();

                //Remplissage de ViewBag avec toutes les questions
                ViewBag.Questions = questions;

                ViewBag.IdQuiz = IdQuiz;
                ViewBag.UserName = UserName;
                
            }
            return View("AfficherQuestionsQuiz");
        }

        [HttpPost]
        [Route("SubmitQuiz")]
        public IActionResult SubmitQuiz(IFormCollection iFormCollection)
        {
            ViewBag.ConfimPasserQuiz = "Une erreur est survenue lors de la soumission du Quiz";
            ViewBag.EtatSoumission = "non";
            int idQuiz = 0;
            if (TempData.ContainsKey("IdQuiz"))
            {
                idQuiz = Convert.ToInt32( TempData["IdQuiz"] as string );
            }
            string userName = "";
            if (TempData.ContainsKey("UserName"))
            {
                userName = TempData["UserName"] as string;
            }
            Debug.WriteLine(" ----- idQuiz : " + idQuiz+ "  ---userName : "+ userName);
            //Chercher dans la table Answer si un enregistrement corespond à QuizId et les supprimer
            List<Answer> existantAnswers = context.Answer.Where(ans => ans.QuizId == idQuiz).ToList();
            if (existantAnswers.Count > 0)
            {
                
                foreach(Answer oldAnswer in existantAnswers)
                {
                    Debug.WriteLine("---existantAnswers quizId" + oldAnswer.QuizId + " idOption : " + oldAnswer.OptionId);
                    context.Remove<Answer>(oldAnswer);
                }
                
            }
            //Insertion des nouveau enregistrements dans la table Answer
            string[] questionIds = iFormCollection["QuestionId"];
            Answer answer;
            foreach (var questId in questionIds)
            {
                Question laQuestion = context.Question.Find(int.Parse(questId));
                int optIdReponseUser = int.Parse(iFormCollection["Question_" + questId]);
                int optionIdIsRight = context.Question.Find(int.Parse(questId))
                    .ItemOption.Where(opt => opt.IsRight == true).FirstOrDefault().OptionId;
                Debug.WriteLine("quizId: "+ idQuiz+" QuestionId : "+ questId+" ----OptionId Reponse : "+ optIdReponseUser+" ----OptionId Right : "+ optionIdIsRight);
                
                answer = new Answer();
                answer.OptionId = optIdReponseUser;
                answer.QuizId = idQuiz; 
                context.Add<Answer>(answer);
                
            }
            Debug.WriteLine("---------Avant le context.SaveChanges()");
            context.SaveChanges();
            ViewBag.EtatSoumission = "oui";
            ViewBag.ConfimPasserQuiz = "L'utilisateur : "+ userName+" a bien passé le quiz ID : "+ idQuiz;
            return View("ResultatsQuiz");
        }
        public IActionResult ReviserQuizPasse(int IdQuiz, string UserName)
        {
           
            Debug.WriteLine("-----Revision Quiz-----id------24- --Username----rrr-------");
            //Recherche pour IdQuiz de toutes les questions avec leurs ItemOptions
            List<int> listIdQuesQuiz = context.QuestionQuiz.Where(q => q.QuizId == IdQuiz).Select(q => q.QuestionId).ToList();
            //Recherche des questions relatives à la liste listIdQuesQuiz
            List<Question> questions = context.Question.Where(q => listIdQuesQuiz.Contains(q.QuestionId)).ToList();
            //Recherche des Options réponse de la table Answer concernant ce quiz
            List<Answer> answers = context.Answer.Where(a => a.QuizId == IdQuiz).ToList();
            ViewBag.Questions = questions;
            ViewBag.IdQuiz = IdQuiz;
            ViewBag.UserName = UserName;
            ViewBag.Reponses = answers;

            int score = 0;
            foreach (var questId in listIdQuesQuiz)
            {
                int optionIdIsRight = context.Question.Find(questId)
                    .ItemOption.Where(opt => opt.IsRight == true).FirstOrDefault().OptionId;
                int answerOpId = context.Question.Find(questId).ItemOption
                    .Where(opt => answers.Select(a => a.OptionId).Contains(opt.OptionId)).FirstOrDefault().OptionId;
                if (optionIdIsRight == answerOpId)
                {
                    score++;
                }
            }
            Debug.WriteLine("----Score est :  " + score);
            ViewBag.Score = ""+score+" / "+ questions.Count+" bonnes réponses";
            return View("ReviserQuiz");
        }
      
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
