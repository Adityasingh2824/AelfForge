import re
import spacy
from collections import Counter

nlp = spacy.load("en_core_web_sm")  # Load a suitable spaCy model

def extract_keywords(text):
    """Extracts keywords from text using spaCy."""
    doc = nlp(text)
    keywords = [token.text for token in doc if not token.is_stop and token.is_alpha]
    keyword_freq = Counter(keywords)
    return keyword_freq.most_common(10)  # Top 10 keywords

def analyze_comments(contract_file):
    """Analyzes comments within a contract file."""
    with open(contract_file, "r") as f:
        code = f.read()
        comments = re.findall(r"(/\*.*?\*/|//.*?$)", code, re.MULTILINE | re.DOTALL)

        all_comments_text = " ".join(comments)
        keywords = extract_keywords(all_comments_text)

        return {
            "total_comments": len(comments),
            "keywords": keywords
        }

def analyze_user_input(user_input):
    """Analyzes user input for potential method calls."""
    doc = nlp(user_input)
    potential_methods = [token.text for token in doc if token.pos_ == "VERB"]

    return potential_methods
