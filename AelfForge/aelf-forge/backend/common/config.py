import os
from dotenv import load_dotenv

load_dotenv()  # Load environment variables from .env file

# aelf Node Configuration
NODE_URL = os.getenv("NODE_URL", "http://127.0.0.1:8000")

# Account Information (for deploying and interacting with contracts)
ACCOUNT_ADDRESS = os.getenv("ACCOUNT_ADDRESS")
ACCOUNT_PASSWORD = os.getenv("ACCOUNT_PASSWORD")

# Contract Information (replace with your actual contract addresses)
VOTING_CONTRACT_ADDRESS = os.getenv("VOTING_CONTRACT_ADDRESS")
TIMELOCK_CONTRACT_ADDRESS = os.getenv("TIMELOCK_CONTRACT_ADDRESS")
OWNABLE_CONTRACT_ADDRESS = os.getenv("OWNABLE_CONTRACT_ADDRESS")

# Other Configuration Settings
PROJECT_DIR = os.getenv("PROJECT_DIR", "your_project_directory")  # Replace with your actual project directory
CONTRACT_DIR = os.path.join(PROJECT_DIR, "contracts")
TEMPLATE_DIR = os.path.join(PROJECT_DIR, "templates")

# ... (Add more configuration options as needed)
