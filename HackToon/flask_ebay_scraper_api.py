import requests
from flask import Flask, request, jsonify
from bs4 import BeautifulSoup

app = Flask(__name__)
app.config["DEBUG"] = True


@app.route("/", methods=["GET"])
def scrapeEbay():
    comic_series = request.args["series"]
    character_name = request.args["name"]
    issue_number = request.args["issue"]

    headers = {
        "User-Agent": "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36",
        "Accept-Encoding": "identity"
    }
    search_url = f"https://www.ebay.com/sch/i.html?_from=R40&_nkw={comic_series} {character_name}"
    search_results = requests.get(search_url, headers=headers)
    soup = BeautifulSoup(search_results.text, "html.parser")
    
    titles = [title.text for title in soup.find_all("h3", {"class": "s-item__title"})[1:]]
    prices = [price.text for price in soup.find_all("span", {"class": "s-item__price"})]
    links = [link.get("href") for link in soup.find_all("a", {"class": "s-item__link"})]
    
    return jsonify({"titles": titles[:3], "prices": prices[:3], "links": links[:3]})


app.run()

# scrapeAmazon("spiderman", "spiderman", "1")
