import logclass
import http.server  
import urllib  

class SimpleRequestHandler(http.server.BaseHTTPRequestHandler):  
	def do_Head(self):
		logclass.LogInTxt("head")
	def do_GET(self):  
		logclass.LogInTxt("get")	
	def do_POST(self):  
		contentlength = int(self.headers['content-length'])
		datas = self.rfile.read(contentlength)
		self.send_response(200)
		self.end_headers()
		self.wfile.write(self.handlerPostData(datas))
	def handlerPostData(self, datas):
		result = bytearray()
		for data in datas:
			result.append(data + 1)
		return result

if __name__ == "__main__":
	addr = ('',8765)  
	with http.server.socketserver.TCPServer(addr, SimpleRequestHandler) as httpserver:
		logclass.LogInTxt("start server")
		httpserver.serve_forever()  