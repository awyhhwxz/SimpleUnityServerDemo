import logclass
import http.server  
import urllib  
import post_jsondata_handler

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
		self.wfile.write(self.hanldePostJsonData(datas))

	def hanldePostJsonData(self, datas):
		return post_jsondata_handler.simlpe_post_json_handle(datas)

	def handlePostData(self, datas):
		result = bytearray()
		for data in datas:
			result.append(data + 1)
		return datas

if __name__ == "__main__":
	addr = ('',8765)  
	with http.server.socketserver.TCPServer(addr, SimpleRequestHandler) as httpserver:
		httpserver.serve_forever()  