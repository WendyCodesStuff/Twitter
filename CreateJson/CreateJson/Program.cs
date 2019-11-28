
using System;
using System.IO;
using Newtonsoft.Json;



class Program
{
	static void Main()
	{


		var root = new
		{
			tweets = new[] {
									new{ text = "'We write to taste life twice, in the moment and in retrospect.' - Anaïs Nin #amwriting #bookworm" },
									new{ text = "'If there's a book that you want to read, but it hasn't been written yet, then you must write it.' - Toni Morrison #amwriting" },
									new{ text = "'Either write something worth reading or do something worth writing.' - Benjamin Franklin #amwriting" },
									new{ text = "'You never have to change anything you got up in the middle of the night to write.' - Saul Bellow.  #sotrue #amwriting" },
                                    new{ text = "'I fulfil my own need for storytelling by telling my own stories…while my husband watches TV!' - Wena Poon #LitFest #amwriting" },
									new{ text = "'I write because fiction is my way of thinking about the world. - Madeleine Thien #BookwormLitFest #LitFest" },
									new{ text = "'If you don't have time to read, you don't have the time(or the tools) to write. Simple as that.' - Stephen King #amwriting" },
									new{ text = "'He loved libraries. Nowhere else in the world felt so safe and homey. Nowhere else smelled like books and dust and happy solitude quite like a library did.' - First Kill by Heather Brewer #lovelibraries #loveyourlibrary" },
									new{ text = "'A writer is someone for whom writing is more difficult than it is for other people.' - Thomas Mann, Essays of Three Decades #amwriting" },
									new{ text = "'You can make anything by writing.' - C.S. Lewis #amwriting" },
									new{ text = "'Writers live twice.' - Natalie Goldberg #amwriting" },
                                    new{ text = "'I spent three days a week for 10 years educating myself in the public library, and it's better than college. ... At the end of 10 years, I had read every book in the library and I'd written a thousand stories.' - Ray Bradbury #amwriting" },
                                    new{ text = "'The first draft is just you telling yourself the story.' - Terry Pratchett, #amwriting #writedrunkeditsober" },
                                    new{ text = "'You can always edit a bad page. You can’t edit a blank page.' - Jodi Picoult #amwriting #writedrunkeditsober" },
                                    new{ text = "'Start writing, no matter what. The water does not flow until the faucet is turned on.' - Louis L’Amour #amwriting #writedrunkeditsober" },
                                    new{ text = "'The worst enemy to creativity is self-doubt.' -  Sylvia Path #amwriting" },
                                    new{ text = "'Everybody walks past a thousand story ideas every day. The good writers are the ones who see five or six of them. Most people don’t see any.' - Orson Scott #amwriting" },
                                    new{ text = "'There is no greater agony than bearing an untold story inside you.' - Maya Angelou #amwriting" },
                                    new{ text = "'Don’t bend; don’t water it down; don’t try to make it logical; don’t edit your own soul according to the fashion. Rather, follow your most intense obsessions mercilessly.' - Franz Kafka #amwriting" },
                                    new{ text = "'If the book is true, it will find an audience that is meant to read it.' - Wally Lamb #amwriting" },
                                    new{ text = "'I think all writing is a disease. You can’t stop it.' - William Carlos Williams #amwriting" },
                                    new{ text = "'A professional writer is an amateur who didn’t quit.' - Richard Bach #amwriting" },
                                    new{ text = "'A good writer doesn’t really need to be told anything except to keep at it.' - Chinua Achebe #amwriting" },
                                    new{ text = "'Write drunk. Edit Sober' - Earnest Hemingway #writedrunkeditsober  #amwriting" },
                                    new{ text = "'Don’t tell me the moon is shining; show me the glint of light on broken glass.' - Anton Chekhov #amwriting" }


                    }
        };

		string jsonStr = JsonConvert.SerializeObject(root);

		Console.WriteLine(jsonStr);

		string path = "jsonTweets.json";

		File.WriteAllText(path, jsonStr);

	}
}
