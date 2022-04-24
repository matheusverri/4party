from django.contrib import admin
from .models import Cliente,Sexo,Produto,Ingresso,ConsumoCliente,IngressoCliente
# Register your models here.

admin.site.register(Sexo)
admin.site.register(Cliente)
admin.site.register(Produto)
admin.site.register(Ingresso)
admin.site.register(ConsumoCliente)
admin.site.register(IngressoCliente)
# admin.site.register(ProdutoConsumo)
