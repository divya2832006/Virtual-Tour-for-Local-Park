# server.py
from http.server import SimpleHTTPRequestHandler, HTTPServer
import sys

PORT = 8080

try:
    server = HTTPServer(('localhost', PORT), SimpleHTTPRequestHandler)
    print(f"Serving HTTP on http://localhost:{PORT} (press CTRL+C to stop)")
    server.serve_forever()
except KeyboardInterrupt:
    print("\nServer stopped by user")
    sys.exit(0)
