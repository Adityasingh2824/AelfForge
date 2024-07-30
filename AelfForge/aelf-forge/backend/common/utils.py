import json
import subprocess

def call_contract_method(contract_address, method_name, params, account, password):
    """Calls a method on a deployed contract."""
    # Convert parameters to JSON string
    params_json = json.dumps(params)

    # Construct the aelf-command call
    cmd = [
        "aelf-command", "call",
        "--account", account,
        "--password", password,
        "--contract", contract_address,
        "--method", method_name,
        "--params", params_json
    ]

    result = subprocess.run(cmd, capture_output=True, text=True)
    return result.stdout

def get_contract_state(contract_address, state_variable, account, password):
    """Gets the value of a state variable from a contract."""
    cmd = [
        "aelf-command", "get-contract-state",
        "--account", account,
        "--password", password,
        "--contract", contract_address,
        "--state", state_variable
    ]

    result = subprocess.run(cmd, capture_output=True, text=True)
    return result.stdout

def encode_parameters(types, values):
    """Encodes parameters for a contract method call."""
    # ... (Implementation for encoding parameters based on their types)

def decode_result(result_type, encoded_result):
    """Decodes the result of a contract method call."""
    # ... (Implementation for decoding the result based on its type)
